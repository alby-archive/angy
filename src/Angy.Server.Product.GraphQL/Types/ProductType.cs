using System;
using System.Collections.Generic;
using System.Linq;
using Angy.Model;
using Angy.Server.Data;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Angy.Server.Product.GraphQL.Types
{
    public sealed class ProductType : ObjectGraphType<Model.Product>
    {
        public ProductType(IServiceProvider provider, IDataLoaderContextAccessor dataLoader)
        {
            Name = "Product";
            Description = "A products sold by the company.";

            Field(d => d.Id).Description("The id of the product.");
            Field(d => d.Name).Description("The name of the product.");
            Field(d => d.CategoryId).Description("The id og the product category.");

            Field<CategoryType, Category>()
                .Name("category")
                .Description("The product category.")
                .ResolveAsync(async context =>
                {
                    var loader = dataLoader.Context.GetOrAddBatchLoader<Guid, Category>("GetCategoryByIds", async ids =>
                        await provider.GetRequiredService<LuciferContext>()
                            .Categories
                            .Where(micro => ids.Contains(micro.Id))
                            .ToDictionaryAsync(e => e.Id));

                    return await loader.LoadAsync(context.Source.CategoryId);
                });

            Field<ListGraphType<AttributeDescriptionType>, IEnumerable<AttributeDescription>>()
                .Name("descriptions")
                .Description("The product attributes.")
                .ResolveAsync(async context =>
                {
                    var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<Guid, AttributeDescription>("GetAttributesByProductId", async ids =>
                        (await provider.GetRequiredService<LuciferContext>()
                            .AttributeDescriptions
                            .Where(description => ids.Contains(description.ProductId))
                            .ToListAsync())
                        .ToLookup(e => e.ProductId));

                    return await loader.LoadAsync(context.Source.Id);
                });
        }
    }
}
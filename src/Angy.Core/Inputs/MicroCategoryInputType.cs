﻿using Angy.Model.Model;
using GraphQL.Types;

namespace Angy.Core.Inputs
{
    public sealed class MicroCategoryInputType : InputObjectGraphType<MicroCategory>
    {
        public MicroCategoryInputType()
        {
            Name = "MicroCategoryInput";

            // Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Description);
        }
    }
}
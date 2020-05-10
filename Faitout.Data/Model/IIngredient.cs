using System;
using System.Collections.Generic;

namespace Faitout.Data.Model
{
    public interface IIngredient
    {
        Guid Id { get; set; }
        bool IsAllergen { get; set; }
        bool IsOrganic { get; set; }
        string Name { get; set; }
    }
}
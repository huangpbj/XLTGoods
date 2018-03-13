using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XLTGoods.Models
{
    [MetadataType(typeof(PropertyMetadata))]
    public partial class Property
    {

    }


     public class PropertyMetadata
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide PName")]
            public string PName { get; set; }
        }
}
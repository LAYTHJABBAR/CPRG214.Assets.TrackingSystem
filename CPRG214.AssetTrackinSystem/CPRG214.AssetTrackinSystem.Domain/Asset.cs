using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace CPRG214.AssetTrackingSystem.Domain
{
    public class Asset
    {
        // Properties
        public int Id { get; set; }
        [Display(Name = "Tag Number")] [Required] public string TagNumber { get; set; }
        [Display(Name = "Asset Type")] [Required] public int AssetTypeId { get; set; }
        [Required] public string Manufacturer { get; set; }

        [AllowNull] public string? Model { get; set; }
        [Required] public string Description { get; set; }
        [Display(Name = "Serial Number")] [Required] public string SerialNumber { get; set; }

        // Navigation Properties

        [Display(Name = "Asset Type")] public AssetType AssetType { get; set; }
    }
}

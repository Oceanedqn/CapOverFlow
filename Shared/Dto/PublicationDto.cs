using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CapOverFlow.Shared.Dto
{
    [Table("publication_PBC")]
    public class PublicationDto
    {
        public PublicationDto()
        {
        }
        [Column("PBC_id")]
        public int PbcId { get; set; }
        
        [Required(ErrorMessage = "Le titre est obligatoire et ne doit pas dépasser 100 caractères")]
        [DisplayName("Title")]
        [StringLength(100)]
        [Column("PBC_title")]
        public string PbcTitle { get; set; }
        
        [Required(ErrorMessage = "La description est obligatoire et ne doit pas dépasser 8000 caractères")]
        [StringLength(8000)]
        [Column("PBC_description")]
        public string PbcDescription { get; set; }
        
        [Required]
        [Column("PBC_resolved")]
        public bool PbcResolved { get; set; }
        
        [Required]
        [Column("PBC_date")]
        public DateTime PbcDate { get; set; }
        
        [Required]
        [Column("TAG_id")]
        [Range(1, int.MaxValue, ErrorMessage = "Le tag est obligatoire. Vérifie s'il a bien été ajouté en appuyant sur le bouton plus.")]
        public int TagId { get; set; }
        
        [Required]
        [Column("USR_id")]
        public int UsrId { get; set; }
       
        [Required]
        [Column("TYP_id")]
        public int TypId { get; set; }

        public virtual TagDto Tag { get; set; }
        public virtual TypeDto Typ { get; set; }
        public virtual UserDto Usr { get; set; }
    }
}

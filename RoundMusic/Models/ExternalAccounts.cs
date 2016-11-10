using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RoundMusic.Models
{
    public class ExternalAccounts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TokenId { get; set; }
        public string ServiceName { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace testweb2.Models
{
    public class VotesInfo
    {
        [Key]
        public int VoteId { get; set; }
        public int NoteId { get; set; }
        public int ChoiceCounts { get; set; }
        public bool ChoiceOption { get; set; }
    }
    public class VotesData
    {
        [Key]
        public int Id { get; set; }
        public int VoteId { get; set; }
        public int ChoiceId { get; set; }
        public string ChoiceSen { get; set; }

    }

    public class VoteRes
    {
        [Key]
        public int Id { get; set; }
        public int VoteId { get; set; }
        public int ChoiceCounts { get; set; }
        public int ChoiceId { get; set; }

    }

    public class VotingSysDBContext : DbContext
    {
        public DbSet<VotesInfo> VotesInfos { get; set; }
        public DbSet<VotesData> VotesDatas { get; set; }

        public DbSet<testweb2.Models.VoteRes> VoteRes { get; set; }
    }

    public class VoteResDBContext : DbContext
    {
        public DbSet<VoteRes> VoteReses { get; set; }
    }
}
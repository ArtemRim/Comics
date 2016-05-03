using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Comics.Models
{
    public class Cartoon
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public String IdUser { get; set; }

        public virtual ApplicationUser User { get; set; }


        public String Name { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public Cartoon()
        {
            Tags = new HashSet<Tag>();
        }
    }

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("Author")]
        public String IdAuthor { get; set; }

        [ForeignKey("User")]
        public String IdUser { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser Author { get; set; }

        public String Text { get; set; }

    }



    public class Medal
    {
        [Key]
        public int Id { get; set; }

        public String ImageURL { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        public Medal()
        {
            Users = new HashSet<ApplicationUser>();
        }
    }

    public class PartDialog
    {

        public int PosX { get; set; }
        public int PosY { get; set; }

        [ForeignKey("Part")]
        public int IdPart { get; set; }

        public virtual Part Part { get; set; }

        [ForeignKey("DialogTemplate")]
        public int IdDialogTemplate { get; set; }

        public virtual DialogTemplate DialogTemplate { get; set; }

    }


    public class DialogTemplate
    {
        [Key]
        public int Id { get; set; }
        public String URL { get; set; }

    }

    public class Voice
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Cartoon")]
        public String IdCartoon { get; set; }

        public virtual Cartoon Cartoon { get; set; }

        public int Mark { get; set; }
    }

    public class Tag
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Cartoon> Cartoons { get; set; }

        public String Name { get; set; }

        public Tag()
        {
            Cartoons = new HashSet<Cartoon>();
        }

    }

    public class PageTemplate
    {
        [Key]
        public int Id { get; set; }
        public String URL { get; set; }


    }
    public class Part
    {
        [Key]
        public int Id { get; set; }

        public String ElementUrl { get; set; }
        public int ElementPosX { get; set; }
        public int ElementPosY { get; set; }

    }

    public class Page
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Cartoon")]
        public int IdCartoon { get; set; }

        public virtual Cartoon Cartoon { get; set; }

        [ForeignKey("PageTemplate")]
        public int IdPageTemplate { get; set; }

        public virtual PageTemplate PageTemplate { get; set; }
    }
}
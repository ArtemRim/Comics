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

        public virtual ICollection<CartoonTag> CartoonTag { get; set; }

        public Cartoon()
        {
            CartoonTag = new HashSet<CartoonTag>();
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
        
        public virtual ICollection<UserMedal> UserMedals { get; set; }

        public Medal()
        {
            UserMedals = new HashSet<UserMedal>();
        }
    }


    public class UserMedal
    {

        [Key, Column(Order = 0)]
        [ForeignKey("Medal")]
        public int IdMedal { get; set; }
        public virtual Medal Medal { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("User")]
        public String IdUser { get; set; }
        public virtual ApplicationUser User { get; set; }

    }


    public class Voice
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Cartoon")]
        public int IdCartoon { get; set; }
        public virtual Cartoon Cartoon { get; set; }

        public int Mark { get; set; }
    }



    public class Tag
    {
        [Key]
        public int Id { get; set; }       
        public String Name { get; set; }

        public virtual ICollection<CartoonTag> CartoonTag { get; set; }
        public Tag()
        {
            CartoonTag = new HashSet<CartoonTag>();
        }

    }


    public class CartoonTag
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Tag")]
        public int IdTag { get; set; }
        public virtual Tag Tag { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Cartoon")]
        public int IdCartoon { get; set; }
        public virtual Cartoon Cartoon { get; set; }

    }

    public class PageTemplate
    {
        [Key]
        public int Id { get; set; }
        public String URL { get; set; }

    }



    public class DialogTemplate
    {
        [Key]
        public int Id { get; set; }
        public String URL { get; set; }

    }



    public class Part
    {
        [Key]
        public int Id { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        [ForeignKey("PageTemplate")]
        public int IdPageTemplate { get; set; }
        public virtual PageTemplate PageTemplate { get; set; }
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

        [ForeignKey("DialogTemplate")]
        public int IdDialogTemplate { get; set; }
        public virtual DialogTemplate DialogTemplate { get; set; }

        public String Content { get; set; }
    }
}
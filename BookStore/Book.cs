using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore
{
    public class PutBookModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // otoimplament olması istediğimiz alan için kullanıyoruz.,frmatlı insert istersek computed kullanırız.
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}

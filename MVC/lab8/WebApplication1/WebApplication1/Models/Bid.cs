using System.ComponentModel;

namespace WebApplication1.Models
{
    public class Bid
    {
        // ID заявки
        public virtual int BidId { get; set; }

        [DisplayName("Имя заявителя")]
        public virtual string Name { get; set; }

        [DisplayName("Название кредита")]
        public virtual string CreditHead { get; set; }

        [DisplayName("Дата подачи заявки")]
        public virtual DateTime bidDate { get; set; }
    }

}

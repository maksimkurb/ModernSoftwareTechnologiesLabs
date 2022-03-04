using System.ComponentModel;

namespace WebApplication1.Models
{
    public class Credit
    {
        // ID кредита
        public virtual int CreditId { get; set; }

        [DisplayName("Название")]
        public virtual string Head { get; set; }

        [DisplayName("Период, на который выдается кредит")]
        public virtual int Period { get; set; }

        [DisplayName("Максимальная сумма кредита")]
        public virtual int Sum { get; set; }

        [DisplayName("Процентная ставка")]
        public virtual int Procent { get; set; }
    }
}

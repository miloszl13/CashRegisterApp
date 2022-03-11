using ApplicationLayer.ViewModels;
using Domain;
using FluentValidation;

namespace CashRegisterApplication.VALIDATION
{
    public class BillNumberValidator: AbstractValidator<BillViewModel>
    {
        public BillNumberValidator()
        {
            RuleFor(x => x.Bill_number).Must(IsValidBillNumber);
        }
        private bool IsValidBillNumber(int billnumber)
        {
            string billnumberstring = billnumber.ToString();
            if(billnumberstring.Length<18)
            {
                return false;
            }
            int controlNumber = Convert.ToInt32(billnumberstring.Substring(billnumberstring.Length - 2));
            long firsttwoparts = Convert.ToInt64(billnumberstring.Substring(0, 16));
            long multiple = firsttwoparts * 100;
            long divide = multiple % 97;
            var result = 98 - divide;
            if(result==controlNumber)
            {
                return true;
            }
            return false;
        }
    }
}

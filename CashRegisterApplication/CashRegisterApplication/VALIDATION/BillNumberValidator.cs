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
        private bool IsValidBillNumber(string billnumber)
        {
           
            if (billnumber.Length < 18)
            {
                return false;
            }
            int controlNumber = Convert.ToInt32(billnumber.Substring(billnumber.Length - 2));
            long firsttwoparts = Convert.ToInt64(billnumber.Substring(0, 16));
            long multiple = firsttwoparts * 100;
            long divide = multiple % 97;
            var result = 98 - divide;
            if (result == controlNumber)
            {
                return true;
            }
            return false;
        }
    }
}

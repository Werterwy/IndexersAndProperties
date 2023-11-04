using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexersAndProperties
{
    public class PaymentCalculator
    {
        private double squareMeters;
        private int residents;
        private int season;
        private int hasDiscount;

        public PaymentCalculator(double squareMeters, int residents, int season, int hasDiscount)
        {
            this.squareMeters = squareMeters;
            this.residents = residents;
            this.season = season;
            this.hasDiscount = hasDiscount;
        }

        public double this[string paymentType]
        {
            get
            {
                switch (paymentType.ToLower())
                {
                    case "отопление":
                        double heatingRate = (season == 1) ? 15 : 10;
                        return squareMeters * heatingRate;
                    case "вода":
                        double waterRate = (season == 1) ? 7 : 5;
                        return residents * waterRate;
                    case "газ":
                        double gasRate = (season == 1) ? 13 : 7;
                        return residents * gasRate;
                    case "ремонт":
                        double repairRate = (season == 1) ? 8 : 5;
                        return squareMeters * repairRate;
                    default:
                        return 0; // Неизвестный тип платежа
                }
            }
        }

        public void CalculatePayments()
        {
            Console.WriteLine("Вид платежа\tНачислено\tЛьготная скидка\tИтого");
            double totalCost = 0;

            string[] paymentTypes = { "Отопление", "Вода", "Газ", "Ремонт" };

            foreach (var paymentType in paymentTypes)
            {
                double paymentAmount = this[paymentType.ToLower()];
                double discount = 0;

                if (hasDiscount == 1 || hasDiscount==2)
                {
                    discount = paymentAmount * ((hasDiscount == 1) ? 0.3 : 0.5);
                }

                double totalAmount = paymentAmount - discount;
                totalCost += totalAmount;

                Console.WriteLine($"{paymentType}\t             {paymentAmount}\t      {discount * 100 / paymentAmount}%\t       {totalAmount}");
            }

            Console.WriteLine("Итого\t{0}", totalCost);
        }
    }

}

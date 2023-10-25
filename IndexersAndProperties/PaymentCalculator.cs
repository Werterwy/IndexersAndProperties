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

        public void CalculatePayments()
        {
            // Базовые тарифы весна/лето
            double heatingRate = 10;
            double waterRate = 5;
            double gasRate = 7; 
            double repairRate = 5;

            if (season == 1) 
            {
                // Базовые тарифы осень/зима
                heatingRate = 15; // на 1 м2
                waterRate = 7; // на 1 человека
                gasRate = 13; // на 1 человека
                repairRate = 8; // на 1 м2

            }

            // Расчет стоимости отопления
            double heatingCost = squareMeters * heatingRate;

            // Расчет стоимости воды
            double waterCost = residents * waterRate;

            // Расчет стоимости газа
            double gasCost = residents * gasRate;

            // Расчет стоимости текущего ремонта
            double repairCost = squareMeters * repairRate;

            // Расчет общей стоимости
            double totalCost = heatingCost + waterCost + gasCost + repairCost;

            // Расчет льготной скидки (если есть)
            double discount = 0;

            if (hasDiscount == 1) // если есть льготы
            {
                discount = totalCost * 0.3; // 30% скидка
                hasDiscount = 30;


            }else if (hasDiscount == 2)
            {
                discount = totalCost * 0.5;
                hasDiscount = 50;
            }

            // Вывод таблицы с платежами
            Console.WriteLine("Вид платежа\tНачислено\tЛьготная скидка\tИтого");
            Console.WriteLine("Отопление  \t{0}      \t{1}%           \t{2}", heatingCost, hasDiscount, heatingCost * (100 - hasDiscount) / 100);
            Console.WriteLine("Вода       \t{0}      \t{1}%           \t{2}", waterCost, hasDiscount, waterCost * (100 - hasDiscount) / 100);
            Console.WriteLine("Газ        \t{0}      \t{1}%           \t{2}", gasCost, hasDiscount, gasCost * (100 - hasDiscount) / 100);
            Console.WriteLine("Ремонт     \t{0}      \t{1}%           \t{2}", repairCost, hasDiscount, repairCost * (100 - hasDiscount) / 100);
            Console.WriteLine("");
            // Вывод итоговой суммы
            Console.WriteLine("Итого      \t{0}", totalCost - discount);
        }
    }

}

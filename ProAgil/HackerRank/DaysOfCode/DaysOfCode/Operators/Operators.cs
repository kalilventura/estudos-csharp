using System;

namespace Operators
{
    public static class Operator
    {
        public static double solve(double meal_cost, int tip_percent, int tax_percent)
        {
            double tip = meal_cost * ((float)tip_percent / 100);
            double tax = meal_cost * ((float)tax_percent / 100);
            double total_cost = Math.Round(meal_cost + tip + tax);
            return total_cost;
        }
    }
}

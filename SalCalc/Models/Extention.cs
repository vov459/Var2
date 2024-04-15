﻿namespace SalCalc
{
    public static class Extention
    {
        //расширения для списка Double, чтобы найти медианное значение
        public static double Median<TColl, TValue>(
            this IEnumerable<TColl> source,
            Func<TColl, TValue> selector)
        {
            return source.Select<TColl, TValue>(selector).Median();
        }
        public static double Median<T>(
                 this IEnumerable<T> source)
        {
            if (Nullable.GetUnderlyingType(typeof(T)) != null)
                source = source.Where(x => x != null);
            int count = source.Count();
            if (count == 0)
                return 0;
            source = source.OrderBy(n => n);
            int midpoint = count / 2;
            if (count % 2 == 0)
                return (Convert.ToDouble(source.ElementAt(midpoint - 1)) + Convert.ToDouble(source.ElementAt(midpoint))) / 2.0;
            else
                return Convert.ToDouble(source.ElementAt(midpoint));
        }
    }

}

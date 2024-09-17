namespace Trial;

class Program
{
    static void Main(string[] args)
    {
        
        Profit[] profits = new Profit[365];

        // Geração dos valores iniciais dos valores
        Random random = new Random();
        for (int i = 0; i < 365; i++)
        {
           
            DateTime currentDate = new DateTime(2023, 1, 1).AddDays(i);
            float totalValue = random.NextDouble() < 0.1 ? 0 : random.Next(10000, 100000);
            profits[i] = new Profit
            {
                date = currentDate,
                total = totalValue
            };
        }
        

        // Total de dias com valores
        int daysWithProfit = profits.Count(x => x.total > 0);

        // Valor médio adquirido no ano
        float medProfit = profits.Sum(x => x.total) / daysWithProfit;

        // Menor valor
        Profit lesserValue = profits.Where(x => x.total > 0).MinBy(x => x.total);
        // Maior valor
        Profit greaterValue = profits.Where(x => x.total > 0).MaxBy(x => x.total);

        // Total de dias acima da média
        int daysAboveMed = profits.Count(x => x.total > medProfit);

        Console.WriteLine("O menor valor de faturamento ocorrido em um dia do ano foi -> R$" + lesserValue.total + " no dia -> " + lesserValue.date.ToShortDateString());
        Console.WriteLine("O maior valor de faturamento ocorrido em um dia do ano foi -> R$" + greaterValue.total + " no dia -> " + greaterValue.date.ToShortDateString());
        Console.WriteLine("Número de dias no ano em que o valor de faturamento diário foi superior à média anual: " + daysAboveMed + " superando o valor de -> R$" + medProfit);
        
    }
}

// Modelo usado como base para o programa
class Profit {
    public DateTime date { get; set; }
    public float total { get; set; }
}

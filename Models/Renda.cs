namespace FlowFinance.Models;
public class Renda
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public decimal Valor { get; set; }
    public DateOnly Data { get; set; }
}

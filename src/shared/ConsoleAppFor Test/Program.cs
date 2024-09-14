// See https://aka.ms/new-console-template for more information

using Bolog.Domain.ArticleAggregate;
using ConsoleAppFor_Test;
using System.Net;


var res = IPAddress.TryParse("94.182.46.220", out IPAddress? ipAddress);
var tag = Tag.Create("ali reza doost dar");
var money1 = new Money(2000, "IIR");
var money2 = new Money(2000, "IIR");
if (money1 != money2)
    Console.WriteLine("no equal");

Console.WriteLine("equal");
Console.WriteLine(money2.Currency.GetHashCode());
Console.WriteLine(money2.Amount.GetHashCode());
Console.WriteLine(money2.Amount.GetHashCode() ^ money2.Currency.GetHashCode());
Console.WriteLine(money1.GetHashCode());

var yel = new yeild();
var yel2 = yel.GetNumbers();
foreach (var number in yel2)
{
    Console.WriteLine(number);
}

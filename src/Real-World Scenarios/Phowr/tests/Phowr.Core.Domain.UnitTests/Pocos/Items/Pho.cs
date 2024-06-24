using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phowr.Core.Domain.UnitTests.Pocos.Items;

public static class Dong
{
    public const decimal NamTram = 500m;
    public const decimal MotNghin = NamTram * 2;
    public const decimal HaiNghin = MotNghin * 2;
    public const decimal NamNghin = MotNghin * 5;
    public const decimal MuoiNghin = NamNghin * 2;
    public const decimal HaiMuoiNgan = MuoiNghin * 2;
    public const decimal NamMuoiNgan = MuoiNghin * 5;
    public const decimal MotTramNgan = NamMuoiNgan * 2;
    public const decimal HaiTramNgan = MotTramNgan * 2;
    public const decimal NamTramNgan = MotTramNgan * 5;
}

public record Pho(string Name, Money UnitPrice) : ISellingItem
{
    public static Pho PhoTai()
        => new(nameof(PhoTai), Money.Create(Dong.MuoiNghin * 3, MoneyCurrency.Dong));

    public static Pho PhoTaiNam()
        => new(nameof(PhoTaiNam), Money.Create(Dong.HaiMuoiNgan * 2, MoneyCurrency.Dong));

    public static Pho PhoTaiLan()
        => new(nameof(PhoTaiLan), Money.Create(Dong.HaiMuoiNgan * 2 + Dong.NamNghin, MoneyCurrency.Dong));

    public static Pho PhoNam()
        => new(nameof(PhoNam), Money.Create(Dong.MuoiNghin * 3, MoneyCurrency.Dong));

    public static Pho PhoBoVien()
        => new(nameof(PhoBoVien), Money.Create(Dong.MuoiNghin * 3 + Dong.NamNghin, MoneyCurrency.Dong));

    public static Pho PhoGa()
        => new(nameof(PhoGa), Money.Create(Dong.MuoiNghin * 3, MoneyCurrency.Dong));

    public static Pho PhoDacBiet()
        => new(nameof(PhoDacBiet), Money.Create(Dong.NamMuoiNgan, MoneyCurrency.Dong));

    public static Pho Empty()
        => new(string.Empty, Money.Zero(MoneyCurrency.Dong));
}

public record Drink(string Name, Money UnitPrice) : ISellingItem
{
    public static Drink TraDa()
        => new(nameof(TraDa), Money.Create(Dong.MuoiNghin, MoneyCurrency.Dong));

    public static Drink NhaDam()
        => new(nameof(TraDa), Money.Create(Dong.MuoiNghin + Dong.NamNghin, MoneyCurrency.Dong));

    public static Drink Coca()
        => new(nameof(Coca), Money.Create(Dong.MuoiNghin + Dong.NamNghin, MoneyCurrency.Dong));
}

public record DrinkUpsize(string Name, Money UnitPrice)
    : Drink(Name, UnitPrice), ISellingItem
{
    public static DrinkUpsize Medium(Drink drink)
        => new(drink.Name, drink.UnitPrice + Dong.NamNghin);

    public static DrinkUpsize Large(Drink drink)
        => new(drink.Name, drink.UnitPrice + Dong.MuoiNghin);
}

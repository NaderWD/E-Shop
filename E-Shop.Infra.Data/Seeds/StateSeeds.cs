using E_Shop.Domain.Models.AddressModels;

namespace E_Shop.Infra.Data.Seeds
{
    public static class StateSeeds
    {
        public static List<State> ApplicationStates { get; } =
        [                                                           
            new() { Id = 1, StateName = StateName.AzarbayejanSharghi },
            new() { Id = 2, StateName = StateName.AzarbayejanGharbi },
            new() { Id = 3, StateName = StateName.Ardebil },
            new() { Id = 4, StateName = StateName.Esfahan },
            new() { Id = 5, StateName = StateName.Alborz },
            new() { Id = 6, StateName = StateName.Ilam },
            new() { Id = 7, StateName = StateName.Bushehr },
            new() { Id = 8, StateName = StateName.Tehran },
            new() { Id = 9, StateName = StateName.ChaharmahalBakhtiari },
            new() { Id = 10, StateName = StateName.KhorasanShomali },
            new() { Id = 11, StateName = StateName.KhorasanJonoobi },
            new() { Id = 12, StateName = StateName.KhorasanRazavi },
            new() { Id = 13, StateName = StateName.Khuzestan },
            new() { Id = 14, StateName = StateName.Zanjan },
            new() { Id = 15, StateName = StateName.Semnan },
            new() { Id = 16, StateName = StateName.SistanBaluchestan },
            new() { Id = 17, StateName = StateName.Fars },
            new() { Id = 18, StateName = StateName.Qazvin },
            new() { Id = 19, StateName = StateName.Qom },
            new() { Id = 20, StateName = StateName.Kurdistan },
            new() { Id = 21, StateName = StateName.Kerman },
            new() { Id = 22, StateName = StateName.Kermanshah },
            new() { Id = 23, StateName = StateName.KohgiluyehBoyerahmad },
            new() { Id = 24, StateName = StateName.Golestan },
            new() { Id = 25, StateName = StateName.Gilan },
            new() { Id = 26, StateName = StateName.Lorestan },
            new() { Id = 27, StateName = StateName.Mazandaran },
            new() { Id = 28, StateName = StateName.Markazi },
            new() { Id = 29, StateName = StateName.Hormozgan },
            new() { Id = 30, StateName = StateName.Hamedan },
            new() { Id = 31, StateName = StateName.Yazd }
        ];
    }

}

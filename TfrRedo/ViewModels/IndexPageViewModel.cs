﻿using Domain.Stations;

namespace TfrRedo.ViewModels
{
    public class IndexPageViewModel : IIndexPageViewModel
    {
        public Station Arrival { get; set; }
        public Station Departure { get; set; }
    }
}
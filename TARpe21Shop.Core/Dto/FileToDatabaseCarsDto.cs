﻿namespace TARpe21Shop.Core.Dto
{
    public class FileToDatabaseDtoCars
    {
        public Guid Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid? CarId { get; set; }
    }
}

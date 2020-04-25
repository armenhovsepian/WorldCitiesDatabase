namespace ConsoleApp.Models
{
    class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Region Parent { get; set; }

    }

    class Country : Region { }
    class City : Region { }

}

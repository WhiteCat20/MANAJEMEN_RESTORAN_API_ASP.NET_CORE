namespace Resto.Domain.DTO
{
    public class AddMHFnbRequestDto
    {
        public string Name { get; set; } = "Nama FNB";
        public int Type { get; set; } = 0;
        public bool ColdHotAvailable { get; set; } = false;
        public int Price { get; set; } = 10000;
    }
}

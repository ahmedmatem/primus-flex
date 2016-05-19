namespace PrimusFlex.Data.Models
{
    using Common.Models;
    using Types;

    public class Site : BaseModel<int>
    {
        public int Name { get; set; }

        public string PostCode { get; set; }

        public string Address { get; set; }

        public KitchenName KitchenName { get; set; }

        /* Property is must be confirmed (set true) by member of admin
        Othe users can create Site but it must be confirmed by member of admin
        */
        public bool Confirmed { get; set; }
    }
}

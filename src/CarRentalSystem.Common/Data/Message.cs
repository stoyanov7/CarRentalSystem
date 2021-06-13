namespace CarRentalSystem.Common.Data
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Message
    {
        public string serializedData;

        public int Id { get; set; }

        public Type Type { get; set; }

        public bool Published { get; set; }

        [NotMapped]
        public object Data
        {
            get => JsonConvert.DeserializeObject(
                this.serializedData,
                this.Type,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            set
            {
                this.Type = value.GetType();

                this.serializedData = JsonConvert.SerializeObject(
                    value,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
        }
    }
}

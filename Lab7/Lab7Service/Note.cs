using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Lab7Service
{
    [DataContract]
    public class Note
    {
        [DataMember]
        [JsonProperty("subject")]
        public string Subj { get; set; }
        [DataMember]
        [JsonProperty("mark1")]
        public int Mark1 { get; set; }
    }

    [CollectionDataContract]
    public class NoteResponse
    {
        public Note[] Value { get; set; }
    }
}

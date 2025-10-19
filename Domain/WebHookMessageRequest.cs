namespace ServiceExpress.Domain
{
    public class WebhookMessageRequest
    {
        public string Object { get; set; }
        public List<Entry> Entry { get; set; }
    }

    public class Entry
    {
        public string Id { get; set; }
        public List<Change> Changes { get; set; }
    }

    public class Change
    {
        public string Field { get; set; }
        public Value Value { get; set; }
    }

    public class Value
    {
        public string Messaging_Product { get; set; }
        public Metadata Metadata { get; set; }
        public List<Contact>? Contacts { get; set; }
        public List<Message>? Messages { get; set; }
    }

    public class Metadata
    {
        public string Display_Phone_Number { get; set; }
        public string Phone_Number_Id { get; set; }
    }

    public class Contact
    {
        public Profile Profile { get; set; }
        public string Wa_Id { get; set; }
    }

    public class Profile
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// Clase genérica para soportar distintos tipos de mensajes (texto, imagen, etc.)
    /// </summary>
    public class Message
    {
        public string From { get; set; }
        public string Id { get; set; }
        public string Timestamp { get; set; }
        public string Type { get; set; }

        // Contenido dinámico según el tipo
        public Text? Text { get; set; }
        public Image? Image { get; set; }
        public Audio? Audio { get; set; }
        public Document? Document { get; set; }
        public Location? Location { get; set; }
        public Video? Video { get; set; }
    }

    public class Text
    {
        public string Body { get; set; }
    }

    public class Image
    {
        public string Id { get; set; }
        public string Mime_Type { get; set; }
        public string? Caption { get; set; }
    }

    public class Audio
    {
        public string Id { get; set; }
        public string Mime_Type { get; set; }
    }

    public class Document
    {
        public string Id { get; set; }
        public string Mime_Type { get; set; }
        public string Filename { get; set; }
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }

    public class Video
    {
        public string Id { get; set; }
        public string Mime_Type { get; set; }
        public string? Caption { get; set; }
    }

}

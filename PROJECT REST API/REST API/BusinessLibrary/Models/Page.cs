using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.Models
{
	public class Page
	{
		#region Constructors
		public Page()
        {
        }

		public Page(int id, string topic, string content, string author)
        {
			Id = id;
			Topic = topic;
			Content = content;
			Author = author;
        }

		public Page(Page instance)
			: this(instance.Id, instance.Topic, instance.Content, instance.Author)
        {
        }

		#endregion

		#region Properties
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "topic")]
		public string Topic { get; set; }

		[JsonProperty(PropertyName = "content")]
		public string Content { get; set; }

		[JsonProperty(PropertyName = "author")]
		public string Author { get; set; }

		#endregion

		#region Methods

		#endregion
	}
}
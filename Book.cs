using System;

public class Book {
	private string? Title { get; set; }
	private int PageCount { get; set; }
	private DateTime PublishedDate { get; set; }
	private string[]? Authors { get; set; }
	private string[]? Cathegories { get; set; }
	private Status Status { get; set; }
	private string? ThumbnailUrl { get; set; }
	private string? ShortDescription { get; set; }

}


/*
 * 
 *    {
      "title": "Unlocking Android",
      "pageCount": 416,
      "publishedDate": "2009-04-01",
      "thumbnailUrl": "https://s3.amazonaws.com/AKIAJC5RLADLUMVRPFDQ.book-thumb-images/ableson.jpg",
      "shortDescription": "Unlocking Android: A Developer's Guide provides concise, hands-on instruction for the Android operating system and development tools. This book teaches important architectural concepts in a straightforward writing style and builds on this with practical and useful examples throughout.",
      "status": "PUBLISH",
      "authors": ["W. Frank Ableson", "Charlie Collins", "Robi Sen"],
      "categories": ["Open Source", "Mobile"]
    },
 * */
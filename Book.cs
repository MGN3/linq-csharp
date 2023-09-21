using System;

public class Book {
	public string? Title { get; set; }
	public int PageCount { get; set; }
	public DateTime PublishedDate { get; set; }
	public string[]? Authors { get; set; }
	public string[]? Categories { get; set; }
	public string? Status { get; set; }
	public string? ThumbnailUrl { get; set; }
	public string? ShortDescription { get; set; }
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
/* 
  	* DefaultValues.cs
	* [ part of Atom.NET library: http://atomnet.sourceforge.net ]
	* Author: Lawrence Oluyede
	* License: BSD-License (see below)
    
	Copyright (c) 2003, 2004 Lawrence Oluyede
    All rights reserved.

    Redistribution and use in source and binary forms, with or without
    modification, are permitted provided that the following conditions are met:

    * Redistributions of source code must retain the above copyright notice,
    * this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
    * notice, this list of conditions and the following disclaimer in the
    * documentation and/or other materials provided with the distribution.
    * Neither the name of the copyright owner nor the names of its
    * contributors may be used to endorse or promote products derived from
    * this software without specific prior written permission.

    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
    AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
    IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
    ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
    LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
    CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
    SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
    INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
    CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
    ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
    POSSIBILITY OF SUCH DAMAGE.
*/
using System;
using System.Text;
using Atom.Core;

namespace Atom.Utils
{
	/// <summary>
	/// Contains default values for Atom feeds.
	/// </summary>
	[Serializable]
	public sealed class DefaultValues
	{
		private DefaultValues() {}
        
		internal const string GeneratorName = "Atom.NET";
		internal static readonly string GeneratorVersion = Utils.GetVersion();
		
		internal const string AtomVersion = "0.3";
		internal const string AtomNSPrefix = "atom";
		internal static readonly Uri AtomNSUri = new Uri("http://purl.org/atom/ns#");

		internal const string DCNSPrefix = "dc";
		internal static readonly Uri DCNSUri = new Uri("http://purl.org/dc/elements/1.1/");

		/// <summary>
		/// The media type of Atom xml format.
		/// </summary>
		public static readonly MediaType AtomMediaType = MediaType.ApplicationAtomXml;

		/// <summary>
		/// The default language of the feed.
		/// </summary>
		public static readonly Language Language = Language.UnknownLanguage;

		/// <summary>
		/// The default value for int values.
		/// </summary>
		public const int Int = -1;

		/// <summary>
		/// The default media type.
		/// It defaults to "text/plain".
		/// </summary>
		public static readonly MediaType MediaType = MediaType.TextPlain;

		/// <summary>
		/// The default encoding mode for the contents.
		/// 
		/// <list type="bullet">
		/// <item>
		///		<term>xml</term>
		///		<description>The content is inline xml.</description>
		/// </item>
		/// <item>
		///		<term>escaped</term>
		///		<description>The content is an escaped string.</description>
		/// </item>
		/// <item>
		///		<term>base64</term>
		///		<description>The content is base64 encoded.</description>
		/// </item>
		/// </list>
		/// 
		/// Processors must decode the element's content before considering it as content of the the indicated media type.  
		/// It defaults to "xml".
		/// </summary>
		public static readonly Mode Mode = Mode.Xml;

		/// <summary>
		/// The default relationship for the links.
		/// 
		/// <list type="bullet">
		/// <item>
		///		<term>alternate</term>
		///		<description>The URI in the href attribute points to an alternate representation of the containing resource.</description>
		/// </item>
		/// <item>
		///		<term>start</term>
		///		<description>The Atom feed at the URI supplied in the href attribute contains the first feed in a linear sequence of entries.</description>
		/// </item>
		/// <item>
		///		<term>next</term>
		///		<description>The Atom feed at the URI supplied in the href attribute contains the next N entries in a linear sequence of entries.</description>
		/// </item>
		/// <item>
		///		<term>prev</term>
		///		<description> The Atom feed at the URI supplied in the href attribute contains the previous N entries in a linear sequence of entries.</description>
		/// </item>
		/// <item>
		///		<term>service.edit</term>
		///		<description>The URI given in the href attribute is used to edit a representation of the referred resource.</description>
		/// </item>
		/// <item>
		///		<term>service.post</term>
		///		<description>The URI in the href attribute is used to create new resources.</description>
		/// </item>
		/// <item>
		///		<term>service.feed</term>
		///		<description>The URI given in the href attribute is a starting point for navigating content and services.</description>
		/// </item>
		/// </list>
		///		
		///	It defaults to "alternate".
		/// </summary>
		public const Relationship Rel = Relationship.Alternate;

		/// <summary>
		/// The default uri for Uri fields.
		/// </summary>
		public static readonly Uri Uri = new Uri("http://www.intertwingly.net/wiki/pie/FrontPage");

		/// <summary>
		/// The default date/time.
		/// </summary>
		public static readonly DateTime DateTime = DateTime.MinValue;

		/// <summary>
		/// The default UTC offset.
		/// </summary>
		public static readonly TimeSpan UtcOffset = TimeSpan.MinValue;

		/// <summary>
		/// The default encoding.
		/// </summary>
		public static readonly Encoding Encoding = Encoding.UTF8;
	}
}

//
// System.Web.UI.ControlCachePolicy
//
// Authors:
//	Dick Porter  <dick@ximian.com>
//      Marek Habersack <mhabersack@novell.com>
//
// Copyright (C) 2005-2008 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

#if NET_2_0

using System.Web.Caching;

namespace System.Web.UI
{
	public sealed class ControlCachePolicy
	{
		BasePartialCachingControl bpcc;
		bool cached;
		
		internal ControlCachePolicy () : this (null)
		{
		}

		internal ControlCachePolicy (BasePartialCachingControl bpcc)
		{
			this.bpcc = bpcc;
		}
		
		public bool Cached 
		{
			get {
				AssertBasePartialCachingControl ();
				return cached;
			}
			
			set {
				AssertBasePartialCachingControl ();
				cached = value;
			}
		}

		public CacheDependency Dependency 
		{
			get {
				AssertBasePartialCachingControl ();
				return bpcc.Dependency;
			}
			set {
				AssertBasePartialCachingControl ();
				bpcc.Dependency = value;
			}
		}

		public TimeSpan Duration 
		{
			get {
				AssertBasePartialCachingControl ();
				return TimeSpan.FromMinutes (bpcc.Duration);
			}
			set {
				AssertBasePartialCachingControl ();
				bpcc.Duration = value.Minutes;
			}
		}

		public bool SupportsCaching 
		{
			get {
				return bpcc != null;
			}
		}

		public string VaryByControl 
		{
			get {
				AssertBasePartialCachingControl ();
				return bpcc.VaryByControls;
			}
			set {
				AssertBasePartialCachingControl ();
				bpcc.VaryByControls = value;
			}
		}

		public HttpCacheVaryByParams VaryByParams {
			get {
				AssertBasePartialCachingControl ();
				throw new NotImplementedException ();
			}
		}

		public void SetExpires (DateTime expirationTime)
		{
			AssertBasePartialCachingControl ();
			bpcc.ExpirationTime = expirationTime;
		}

		public void SetSlidingExpiration (bool useSlidingExpiration)
		{
			AssertBasePartialCachingControl ();
			bpcc.SlidingExpiration = useSlidingExpiration;
		}

		public void SetVaryByCustom (string varyByCustom)
		{
			AssertBasePartialCachingControl ();
			bpcc.VaryByCustom = varyByCustom;
		}

		void AssertBasePartialCachingControl ()
		{
			if (bpcc == null)
				throw new HttpException ("The user control is not associated with a 'BasePartialCachingControl' and is not cacheable.");
		}
		
	}
}
#endif

/* Copyright (c) 2006 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/
#define USE_TRACING
#define DEBUG

using System;
using System.IO;
using System.Xml; 
using System.Collections;
using System.Configuration;
using System.Net; 
using NUnit.Framework;
using Google.GData.Client;
using Google.GData.Client.UnitTests;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.Location;
using Google.GData.Extensions.MediaRss;



namespace Google.GData.Client.LiveTests
{
    [TestFixture] 
    [Category("LiveTest")]
    public class YouTubeTestSuite : BaseLiveTestClass
    {

        //////////////////////////////////////////////////////////////////////
        /// <summary>default empty constructor</summary> 
        //////////////////////////////////////////////////////////////////////
        public YouTubeTestSuite()
        {
        }

        public override string ServiceName
        {
            get {
                return YouTubeService.YTService; 
            }
        }


        //////////////////////////////////////////////////////////////////////
        /// <summary>runs a test on the YouTube Query object</summary> 
        //////////////////////////////////////////////////////////////////////
        [Test] public void YouTubeQueryTest()
        {
            Tracing.TraceMsg("Entering YouTubeQueryTest");

            YouTubeQuery query = YouTubeQuery.VideoQuery();

            query.Formats.Add(YouTubeQuery.VideoFormat.RTSP);
            query.Formats.Add(YouTubeQuery.VideoFormat.Mobile);

            query.Time = YouTubeQuery.UploadTime.ThisWeek;

            Assert.AreEqual(query.Uri.AbsoluteUri, YouTubeQuery.DefaultVideoUri + "?format=1%2C6&time=this_week", "Video query should be identical");

            query = new YouTubeQuery("http://www.youtube.com/feeds?format=1&time=this_week&racy=included");

            Assert.AreEqual(query.Time, YouTubeQuery.UploadTime.ThisWeek, "Should be this week");
            Assert.AreEqual(query.Formats[0], YouTubeQuery.VideoFormat.RTSP, "Should be RTSP");
            Assert.AreEqual(query.Racy, "included", "Racy should be included");


        }
        /////////////////////////////////////////////////////////////////////////////


    } /////////////////////////////////////////////////////////////////////////////
}





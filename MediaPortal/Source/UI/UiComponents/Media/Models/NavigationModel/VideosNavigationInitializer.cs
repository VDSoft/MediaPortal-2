﻿#region Copyright (C) 2007-2013 Team MediaPortal

/*
    Copyright (C) 2007-2013 Team MediaPortal
    http://www.team-mediaportal.com

    This file is part of MediaPortal 2

    MediaPortal 2 is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    MediaPortal 2 is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with MediaPortal 2. If not, see <http://www.gnu.org/licenses/>.
*/

#endregion

using System.Collections.Generic;
using MediaPortal.Common.Commands;
using MediaPortal.UiComponents.Media.General;
using MediaPortal.UiComponents.Media.Models.Navigation;
using MediaPortal.UiComponents.Media.Models.ScreenData;
using MediaPortal.UiComponents.Media.Models.Sorting;

namespace MediaPortal.UiComponents.Media.Models.NavigationModel
{
  class VideosNavigationInitializer : BaseNavigationInitializer
  {
    public VideosNavigationInitializer()
    {
      _mediaNavigationMode = Models.MediaNavigationMode.Videos;
      _mediaNavigationRootState = Consts.WF_STATE_ID_VIDEOS_NAVIGATION_ROOT;
      _viewName = Consts.RES_VIDEOS_VIEW_NAME;
      _necessaryMias = Consts.NECESSARY_VIDEO_MIAS;

      AbstractItemsScreenData.PlayableItemCreatorDelegate picd = mi => new VideoItem(mi) { Command = new MethodDelegateCommand(() => PlayItemsModel.CheckQueryPlayAction(mi)) };

      _defaultScreen = new VideosFilterByGenreScreenData();
      _availableScreens = new List<AbstractScreenData>
        {
          new VideosShowItemsScreenData(picd),
          new VideosFilterByLanguageScreenData(),
          new VideosFilterByActorScreenData(),
          new VideosFilterByDirectorScreenData(),
          new VideosFilterByWriterScreenData(),
          _defaultScreen,
          new VideosFilterByYearScreenData(),
          new VideosFilterBySystemScreenData(),
          new VideosSimpleSearchScreenData(picd),
        };

      _defaultSorting = new SortByTitle();
      _availableSortings = new List<Sorting.Sorting>
        {
          _defaultSorting,
          new SortByYear(),
          new VideoSortByFirstGenre(),
          new VideoSortByDuration(),
          new VideoSortByFirstActor(),
          new VideoSortByFirstDirector(),
          new VideoSortByFirstWriter(),
          new VideoSortBySize(),
          new VideoSortByAspectRatio(),
          new SortBySystem(),
        };
    }
  }
}
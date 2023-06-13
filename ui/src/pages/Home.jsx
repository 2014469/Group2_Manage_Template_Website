/* eslint-disable react-hooks/exhaustive-deps */
import Preview from 'components/Preview';
import SidebarSlugLocal from 'constants/SidebarSlugLocal';
import SectionsGallery from 'containers/SectionsGallery';
import Inspector from 'containers/Inspector';
import Output from 'containers/Output';
import Search from 'containers/Search';
import Settings from 'containers/Settings';
import NarrowSidebar from 'layouts/components/NarowSidebar';
import WideSidebar from 'layouts/components/WideSidebar';
import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import {
  changeSlugActiveTab,
  selectCategorySidebarPaneState,
} from 'store/features/sidebarCategorySlice';
import {
  pushBlock,
  reorderLayout,
  setSelectedBlock,
} from 'store/features/layout';
import RenderHanldebars from 'utils/renderHandlebars';
import SectionsRepository from 'services/SectionsRepository';

Home.propTypes = {};

function Home(props) {
  const dispatch = useDispatch();

  // global state
  const layout = useSelector((state) => state.layout);
  const categorySidebarPane = useSelector(selectCategorySidebarPaneState);

  // destruct
  const { slugActiveTab, previewMode } = categorySidebarPane;

  const { blocks, documentId } = layout;

  const innerHTML = RenderHanldebars();

  function handlePushBlock(blockId) {
    dispatch(pushBlock({ blockId }));
  }

  function handleReorderLayout(newOrder) {
    const newBlocksLayout = [];
    newOrder.forEach((blockUuid) => {
      const block = blocks.find((el) => {
        return el.uuid === blockUuid;
      });

      newBlocksLayout.push(block);
    });

    dispatch(reorderLayout({ newBlocksLayout }));
  }

  function handleMessage(evt) {
    const { event, blockId, newOrder } = evt.data;
    if (event) {
      if (blockId && event === 'click') {
        dispatch(changeSlugActiveTab(SidebarSlugLocal.inspector));
        dispatch(setSelectedBlock({ blockUuid: blockId }));
      } else if (newOrder && event === 'sorted') {
        handleReorderLayout(newOrder);
      }
    }
  }

  useEffect(() => {
    window.addEventListener('message', handleMessage);

    return () => {
      window.removeEventListener('message', handleMessage);
    };
  });

  return (
    <div className='d-flex'>
      <NarrowSidebar />
      <WideSidebar>
        <Inspector />
        <Search onPushBlock={handlePushBlock} />
        <Settings />
        <SectionsGallery
          category='gallery'
          onPushBlock={handlePushBlock}
        />

        {/* <BlocksGallery
          category='header'
          index={SideBarIndex.header}
          onPushBlock={handlePushBlock}
        />
        <BlocksGallery
          category='article'
          index={SideBarIndex.article}
          onPushBlock={handlePushBlock}
        />
        <BlocksGallery
          category='ad'
          index={SideBarIndex.ad}
          onPushBlock={handlePushBlock}
        />

        <Output html={innerHTML} />
        <Inspector /> */}
      </WideSidebar>
      <Preview html={innerHTML} />;
    </div>
  );
}

export default Home;

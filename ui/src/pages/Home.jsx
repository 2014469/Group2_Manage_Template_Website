/* eslint-disable react-hooks/exhaustive-deps */
import Preview from 'components/Preview';
import SidebarSlugLocal from 'constants/SidebarSlugLocal';
import Inspector from 'containers/Inspector';
import Search from 'containers/Search';
import SectionsGallery from 'containers/SectionsGallery';
import Settings from 'containers/Settings';
import NarrowSidebar from 'layouts/components/NarowSidebar';
import WideSidebar from 'layouts/components/WideSidebar';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import {
  reorderLayout,
  selectSectionLayoutEditingState,
  setSelectedBlock,
} from 'store/features/sectionLayoutSlice';
import {
  changeSlugActiveTab,
  selectCategorySidebarPaneState,
} from 'store/features/sidebarCategorySlice';
import RenderHanldebars from 'utils/renderHandlebars';

Home.propTypes = {};

function Home(props) {
  const dispatch = useDispatch();

  // global state
  const sectionLayout = useSelector(selectSectionLayoutEditingState);
  const categorySidebarPane = useSelector(selectCategorySidebarPaneState);

  // destruct
  const { slugActiveTab, previewMode } = categorySidebarPane;

  const { blocks, documentId } = sectionLayout;

  const innerHTML = RenderHanldebars();

  // function handlePushBlock(blockId, data) {
  //   dispatch(pushSection({ blockId, data }));
  // }

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
        <Search onPushBlock={() => {}} />
        <Settings />
        <SectionsGallery />

        {/* <Output html={innerHTML} /> */}
      </WideSidebar>
      <Preview html={innerHTML} />;
    </div>
  );
}

export default Home;

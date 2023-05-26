import React, { useEffect } from 'react';
import PropTypes from 'prop-types';
import { useDispatch, useSelector } from 'react-redux';
import { changeActiveTab } from 'store/features/config';
import SideBarIndex from 'constants/SideBarIndex';
import { getAllCategories } from 'services/CategoriesRepository';

NarrowSidebar.propTypes = {};
function NarrowSidebar(props) {
  const dispatch = useDispatch();

  const { activeTab } = useSelector((state) => state.config);

  function handleChangeActiveTab(index) {
    dispatch(changeActiveTab(index));
  }

  useEffect(() => {
    loadCategories();

    async function loadCategories() {
      var results = await getAllCategories();
      console.log(results);
    }
  }, []);

  return (
    <div className='icons-wrapper bg-dark-blue d-flex flex-column justify-content-between'>
      <div>
        <button
          type='button'
          className={`btn btn-sidebar btn-block m-0 ${
            activeTab === SideBarIndex.inspector ? 'active-button' : ''
          }`}
          onClick={() => handleChangeActiveTab(SideBarIndex.inspector)}
        >
          <span className='material-icons'>edit</span>
        </button>
        <button
          type='button'
          className={`btn btn-sidebar btn-block m-0 ${
            activeTab === SideBarIndex.search ? 'active-button' : ''
          }`}
          onClick={() => handleChangeActiveTab(SideBarIndex.search)}
        >
          <span className='material-icons'>search</span>
        </button>
        <button
          type='button'
          className={`btn btn-sidebar btn-block m-0 ${
            activeTab === SideBarIndex.header ? 'active-button' : ''
          }`}
          onClick={() => handleChangeActiveTab(SideBarIndex.header)}
        >
          <span className='material-icons'>view_quilt</span>
        </button>
        <button
          type='button'
          className={`btn btn-sidebar btn-block m-0 ${
            activeTab === SideBarIndex.article ? 'active-button' : ''
          }`}
          onClick={() => handleChangeActiveTab(SideBarIndex.article)}
        >
          <span className='material-icons'>subject</span>
        </button>
        <button
          type='button'
          className={`btn btn-sidebar btn-block m-0 ${
            activeTab === SideBarIndex.gallery ? 'active-button' : ''
          }`}
          onClick={() => handleChangeActiveTab(SideBarIndex.gallery)}
        >
          <span className='material-icons'>insert_photo</span>
        </button>
        <button
          type='button'
          className={`btn btn-sidebar btn-block m-0 ${
            activeTab === SideBarIndex.ad ? 'active-button' : ''
          }`}
          onClick={() => handleChangeActiveTab(SideBarIndex.ad)}
        >
          <span className='material-icons'>featured_video</span>
        </button>
        <button
          type='button'
          className={`btn btn-sidebar btn-block m-0 ${
            activeTab === SideBarIndex.video ? 'active-button' : ''
          }`}
          onClick={() => handleChangeActiveTab(SideBarIndex.video)}
        >
          <span className='material-icons'>perm_contact_calendar</span>
        </button>
        <button
          type='button'
          className={`btn btn-sidebar btn-block m-0 ${
            activeTab === SideBarIndex.contact ? 'active-button' : ''
          }`}
          onClick={() => handleChangeActiveTab(SideBarIndex.contact)}
        >
          <span className='material-icons'>table_chart</span>
        </button>
        <button
          type='button'
          className={`btn btn-sidebar btn-block m-0 ${
            activeTab === SideBarIndex.table_chart ? 'active-button' : ''
          }`}
          onClick={() => handleChangeActiveTab(SideBarIndex.table_chart)}
        >
          <span className='material-icons'>view_agenda</span>
        </button>
      </div>
      <div>
        <button
          type='button'
          className={`btn btn-sidebar btn-block m-0 ${
            activeTab === SideBarIndex.output ? 'active-button' : ''
          }`}
          onClick={() => handleChangeActiveTab(SideBarIndex.output)}
        >
          <span className='material-icons'>save</span>
        </button>
        <button
          type='button'
          className={`btn btn-sidebar btn-block m-0 ${
            activeTab === SideBarIndex.setting ? 'active-button' : ''
          }`}
          onClick={() => handleChangeActiveTab(SideBarIndex.setting)}
        >
          <span className='material-icons'>settings</span>
        </button>
        <button
          type='button'
          className={`btn btn-sidebar btn-block m-0 ${
            activeTab === SideBarIndex.help ? 'active-button' : ''
          }`}
          onClick={() => handleChangeActiveTab(SideBarIndex.help)}
        >
          <span className='material-icons'>help_outline</span>
        </button>
      </div>
    </div>
  );
}

export default NarrowSidebar;

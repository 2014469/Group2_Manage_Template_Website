import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { useDispatch, useSelector } from 'react-redux';
import {
  changeNameActiveTab,
  changeSlugActiveTab,
  selectCategorySidebarPaneState,
} from 'store/features/sidebarCategorySlice';
import SidebarSlugLocal from 'constants/SidebarSlugLocal';
import { getAllCategories } from 'services/CategoriesRepository';
import SidebarNameLocal from 'constants/SidebarNameLocal';

NarrowSidebar.propTypes = {};
function NarrowSidebar(props) {
  const dispatch = useDispatch();

  // local state
  const [categories, setCategories] = useState([]);

  const { slugActiveTab } = useSelector(selectCategorySidebarPaneState);

  function handleChangeActiveTab(slug, name) {
    dispatch(changeSlugActiveTab(slug));
    dispatch(changeNameActiveTab(name));
  }

  useEffect(() => {
    loadCategories();

    function loadCategories() {
      getAllCategories().then((data) => {
        if (data) {
          setCategories(data);
        } else {
          setCategories([]);
        }
      });
    }
  }, []);

  return (
    <div className='icons-wrapper bg-dark-blue d-flex flex-column justify-content-between'>
      <div>
        <button
          type='button'
          className={`btn btn-sidebar btn-block m-0 ${
            slugActiveTab === SidebarSlugLocal.inspector ? 'active-button' : ''
          }`}
          onClick={() =>
            handleChangeActiveTab(
              SidebarSlugLocal.inspector,
              SidebarNameLocal.inspector,
            )
          }
        >
          <span className='material-icons'>edit</span>
        </button>
        <button
          type='button'
          className={`btn btn-sidebar btn-block m-0 ${
            slugActiveTab === SidebarSlugLocal.search ? 'active-button' : ''
          }`}
          onClick={() =>
            handleChangeActiveTab(
              SidebarSlugLocal.search,
              SidebarNameLocal.search,
            )
          }
        >
          <span className='material-icons'>search</span>
        </button>

        {categories.length > 0
          ? categories.map((category, index) => {
              const { name, icon, urlSlug } = category;
              return (
                <button
                  key={index}
                  type='button'
                  className={`btn btn-sidebar btn-block m-0 ${
                    slugActiveTab === urlSlug ? 'active-button' : ''
                  }`}
                  onClick={() => handleChangeActiveTab(urlSlug, name)}
                  title={name}
                >
                  <span className='material-icons'>{icon}</span>
                </button>
              );
            })
          : null}
      </div>
    </div>
  );
}

export default NarrowSidebar;

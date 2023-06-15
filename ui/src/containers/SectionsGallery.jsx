import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { useSelector } from 'react-redux';
import SectionPreview from 'layouts/components/SectionPreview';
import SidebarSlugLocal from 'constants/SidebarSlugLocal';
import SectionsRepository from 'services/SectionsRepository';
import { selectCategorySidebarPaneState } from 'store/features/sidebarCategorySlice';
import { concatUrlImages } from 'utils/concatUrlImages';
import SidebarNameLocal from 'constants/SidebarNameLocal';

SectionsGallery.propTypes = {};

function SectionsGallery(props) {
  // local state
  const [sections, setSections] = useState([]);

  // global states
  const { slugActiveTab, nameActiveTab } = useSelector(
    selectCategorySidebarPaneState,
  );

  useEffect(() => {
    if (Object.values(SidebarSlugLocal).indexOf(slugActiveTab) === -1) {
      SectionsRepository.getBySlugCategory(slugActiveTab).then((data) => {
        console.log(data);
        if (data) {
          setSections(data.items);
        } else {
          setSections([]);
        }
      });
    } else {
      setSections([]);
    }
  }, [slugActiveTab]);

  return (
    <>
      {Object.values(SidebarSlugLocal).indexOf(slugActiveTab) > -1 ? null : (
        <>
          <h5>Category: {nameActiveTab}</h5>
          <hr />
          {sections.length > 0 ? (
            <>
              {sections.map((section) => {
                const { name, previewImageUrl, urlSlug, id } = section;

                return (
                  <SectionPreview
                    key={id}
                    name={name}
                    blockId={id}
                    sectionSlug={urlSlug}
                    image={concatUrlImages(previewImageUrl)}
                  />
                );
              })}
            </>
          ) : (
            <span>Not have</span>
          )}
        </>
      )}
    </>
  );
}

export default SectionsGallery;

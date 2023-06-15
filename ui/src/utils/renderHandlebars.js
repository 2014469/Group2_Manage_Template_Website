// eslint-disable-next-line
import Handlebars from 'handlebars/dist/cjs/handlebars';

import staticDocuments from '../views/documents';

import section from '../views/section';
import staticBlocks from '../views/blocks';
import { useSelector } from 'react-redux';
import { selectSectionLayoutEditingState } from 'store/features/sectionLayoutSlice';

function RenderHanldebars() {
  const sectionLayoutEditing = useSelector(selectSectionLayoutEditingState);

  const { blocks, documentId } = sectionLayoutEditing;

  const innerHTML = blocks.reduce((acc, sectionData) => {
    console.log(sectionData);
    const { hbs, defaultData } = sectionData.data;

    const blockTemplate = Handlebars.compile(hbs);

    const blockHTML = blockTemplate(defaultData);

    const sectionTemplate = Handlebars.compile(section);
    const sectionHTML = sectionTemplate({
      content: blockHTML,
      uuid: sectionData.uuid,
    });
    return `${acc}${sectionHTML}`;
  }, ``);

  return Handlebars.compile(staticDocuments[documentId].hbs)({
    content: innerHTML,
  });
}

export default RenderHanldebars;

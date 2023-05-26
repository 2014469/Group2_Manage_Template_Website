// eslint-disable-next-line
import Handlebars from 'handlebars/dist/cjs/handlebars';

import staticDocuments from '../views/documents';

import section from '../views/section';
import staticBlocks from '../views/blocks';
import { useSelector } from 'react-redux';

function RenderHanldebars() {
  const layout = useSelector((state) => state.layout);
  const { blocks, documentId } = layout;

  const innerHTML = blocks.reduce((acc, layoutBlock) => {
    const blockHbs = staticBlocks[layoutBlock.blockId].hbs;
    const blockTemplate = Handlebars.compile(blockHbs);
    const blockHTML = blockTemplate(layoutBlock.data);
    const sectionTemplate = Handlebars.compile(section);
    const sectionHTML = sectionTemplate({
      content: blockHTML,
      uuid: layoutBlock.uuid,
    });
    return `${acc}${sectionHTML}`;
  }, ``);

  return Handlebars.compile(staticDocuments[documentId].hbs)({
    content: innerHTML,
  });
}

export default RenderHanldebars;

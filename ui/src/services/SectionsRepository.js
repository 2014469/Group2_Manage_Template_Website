import { get_api } from './method';

const SectionsRepository = {
  getBySlugCategory(slugCate) {
    return get_api(`/sections`, {
      CategorySlug: slugCate,
    });
  },

  getDetailSectionBySlug(slug) {
    return get_api(`/sections/${slug}`);
  },
};

export default SectionsRepository;

import { get_api } from './method';

export async function getAllCategories() {
  return get_api('/categories');
}

export async function getCategoryBySlug(slug) {
  return get_api(`/categories/byslug/${slug}`);
}

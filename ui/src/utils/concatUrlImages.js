export function concatUrlImages(urlImage) {
  return urlImage.startsWith('https')
    ? urlImage
    : `${process.env.REACT_APP_API_ENDPOINT}/${urlImage}`;
}

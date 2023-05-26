const { default: myconfig } = require('myconfig');
const { default: Home } = require('pages/Home');

const publicRoutes = [{ path: myconfig.publicRoutes.home, component: Home }];

export { publicRoutes };

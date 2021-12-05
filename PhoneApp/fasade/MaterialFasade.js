// Author: Michal Zavadil (xzavad18)
class MaterialFasade {
  constructor() {
    this.api_url =
      'https://carserviceapi20211201175316.azurewebsites.net/api/material';
  }
  async GetMaterials() {
    let reponse = await fetch(this.api_url, {
      method: 'GET',
    });
    let data = await reponse.json();
    return data;
  }
}

export default MaterialFasade;

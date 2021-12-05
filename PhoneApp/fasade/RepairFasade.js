class RepairFasade {
  constructor() {
    this.api_url =
      'https://carserviceapi20211201175316.azurewebsites.net/api/repair';
  }
  async GetRepairs() {
    let reponse = await fetch(this.api_url, {
      method: 'GET',
    });
    let data = await reponse.json();
    return data;
  }

  async GetRepairById(id) {
    let reponse = await fetch(this.api_url + '/' + id, {
      method: 'GET',
    });
    let data = await reponse.json();
    return data;
  }
}

export default RepairFasade;

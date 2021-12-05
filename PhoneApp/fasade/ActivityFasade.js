// Author: Michal Zavadil (xzavad18)
class ActivityFasade {
  constructor() {
    this.api_url =
      'https://carserviceapi20211201175316.azurewebsites.net/api/activity';
  }
  async GetActivities() {
    let reponse = await fetch(this.api_url, {
      method: 'GET',
    });
    let data = await reponse.json();
    return data;
  }

  async GetActivityById(id) {
    let reponse = await fetch(this.api_url + '/' + id, {
      method: 'GET',
    });
    let data = await reponse.json();
    return data;
  }
  async CreateActivity(requestData) {
    let reponse = await fetch(this.api_url, {
      method: 'POST',
      body: JSON.stringify(requestData),
      headers: {
        'Content-Type': 'application/json',
      },
    });
    let data = await reponse.json();
    return data;
  }
  async UpdateActivity(requestData) {
    let reponse = await fetch(this.api_url, {
      method: 'PUT',
      body: JSON.stringify(requestData),
      headers: {
        'Content-Type': 'application/json',
      },
    });
  }
}

export default ActivityFasade;

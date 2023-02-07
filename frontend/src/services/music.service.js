import axios from 'axios';

const API_URL = 'http://localhost:55527/api/';

class MusicService {
  getSong() {
    return axios.get(`${API_URL}song`);
  }

  createSong(song) {
    return axios.post(`${API_URL}song`, song);
  }

  updateSong(song) {
    return axios.put(`${API_URL}song/${song.id}`, song);
  }

  deleteSong(id) {
    return axios.delete(`${API_URL}song/${id}`);
  }
}

export default new MusicService();

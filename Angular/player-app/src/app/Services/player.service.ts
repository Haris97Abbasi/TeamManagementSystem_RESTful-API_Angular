import { inject, Injectable } from '@angular/core';
import { Player } from '../Models/player';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  private apiUrl = 'https://localhost:7003/api/Player'
  constructor() { }

  http = inject(HttpClient)

  getAllPlayers() {
    return this.http.get<Player[]>(this.apiUrl);
  }

  addPlayer(data: any) {
    return this.http.post(this.apiUrl, data);
  }

  updatePlayer(player: Player){
    return this.http.put(`${this.apiUrl}/${player.id}`, player);
  }

  deletePlayer(id: number){
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

}

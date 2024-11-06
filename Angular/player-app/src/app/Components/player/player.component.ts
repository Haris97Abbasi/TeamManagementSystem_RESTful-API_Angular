import { Component, ElementRef, inject, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Player } from '../../Models/player';
import { PlayerService } from '../../Services/player.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-player',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './player.component.html',
  styleUrl: './player.component.css'
})
export class PlayerComponent implements OnInit {

  @ViewChild('myModal') model: ElementRef | undefined;

  playerList: Player[] = [];

  playerService = inject(PlayerService);

  playerForm: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder) { }
  
  ngOnInit(): void {
    this.setFormState();
    this.getPlayers();
  }

  openModal() {
    const empModal = document.getElementById('myModal');
    if (empModal != null) {
      empModal.style.display = 'block';
    }
  }

  closeModal() {
    this.setFormState();
    if (this.model != null) {
      this.model.nativeElement.style.display = 'none';
    }
  }

  formValues: any;

  onSubmit() {
    console.log(this.playerForm.value);
    if (this.playerForm.invalid) {
      alert('Please Fill All Fields');
      return;
    }
    if (this.playerForm.value.id == 0) {
      this.formValues = this.playerForm.value;
      this.playerService.addPlayer(this.formValues).subscribe((res) => {
        alert('Player Added Successfully');
        this.getPlayers();
        this.playerForm.reset();
        this.closeModal();
      });
    }
    else{
      this.formValues = this.playerForm.value;
      this.playerService.updatePlayer(this.formValues).subscribe((res) => {
        this.getPlayers();
        alert('Player Updated Successfully');
        this.playerForm.reset();
        this.closeModal();
      });
    }
  }

  getPlayers() {
    this.playerService.getAllPlayers().subscribe((res) => {
      this.playerList = res;
    })
  }

  setFormState() {
    this.playerForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      position: ['', [Validators.required]],
      age: ['', [Validators.required]],
      team: ['', [Validators.required]],
      country: ['', [Validators.required]]
    });
  }

  onDelete(player: Player) {
    const isConfirm = confirm("Are you sure you want to delete this Player: " + player.name);
    if (isConfirm) {
      this.playerService.deletePlayer(player.id).subscribe((res) => {
        alert("Player Deleted Successfully");
        this.getPlayers();
      });
    }
  }

  onEdit(player: Player) {
    this.openModal();
    this.playerForm.patchValue(player);
  }



}

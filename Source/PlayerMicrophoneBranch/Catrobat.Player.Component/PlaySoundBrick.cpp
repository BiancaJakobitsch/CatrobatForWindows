#include "pch.h"
#include "PlaySoundBrick.h"
#include "SoundManager.h"

PlaySoundBrick::PlaySoundBrick(string filename, string name, Script *parent) :
	Brick(TypeOfBrick::PlaySoundBrick, parent),
	m_filename(filename), m_name(name)
{
}

void PlaySoundBrick::Execute()
{
	SoundManager::Instance()->CreateOrGetSound(m_filename)->Play();
}
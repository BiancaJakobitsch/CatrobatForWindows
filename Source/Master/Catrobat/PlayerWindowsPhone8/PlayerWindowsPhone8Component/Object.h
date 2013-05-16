#pragma once

#include <string>
#include <list>

#include "Look.h"
#include "Script.h"
#include "SoundInfo.h"

using namespace std;

struct Bounds
{
    float x;
    float y;
	float width;
	float height;
};

class Object : BaseObject
{
public:
	Object(string name);
	~Object();

	void addLook(Look *lookData);
	void addScript(Script *script);
	void addSoundInfo(SoundInfo *soundInfo);

	void LoadTextures(ID3D11Device* d3dDevice);
	void Draw(SpriteBatch *spriteBatch);
	void StartUp();

	int ScriptListSize();
	Script *getScript(int index);
	string getName();

	int LookDataListSize();
	Look *getLook(int index);
	void SetLook(int index);
	Look* GetCurrentLook();

	void SetPosition(float x, float y);
	void GetPosition(float &x, float &y);

	Bounds getBounds();

	void SetTransparency(float transparency);
	void SetRotation(float rotation);
	float GetRotation();
	void SetScale(float scale);
	float GetScale();

private:
	Look *m_look;
	list<Look*> *m_lookList;
	list<Script*> *m_scripts;
	list<SoundInfo*> *m_soundInfos;
	string m_name;
	float m_opacity;
	float m_rotation;
};